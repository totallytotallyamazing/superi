using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Web.UI;
using System.IO;
using Dev.Mvc.Runtime;
using System.Collections;
using Superi.Web.Mvc.Localization;
using System.Data.Objects.DataClasses;
using System.Reflection;

namespace Shop.Helpers
{
    public static class Localizationup
    {
        struct ModelDetails
        {
            public string EntityName;
            public string EntityId;
            public string FieldName;
            public string DefaultValue;

            public static ModelDetails Create<TModel, TProperty>(TModel model, Expression<Func<TModel, TProperty>> expression) where TModel : class
            {
                string entityId = null;
                string defaultValue = null;
                if (model != null)
                {
                    entityId = ((dynamic)model).Id.ToString();
                    defaultValue = expression.Compile().Invoke(model) as string;
                }
                string entityName = typeof(TModel).Name;
                string fieldName = (expression.Body as MemberExpression).Member.Name;

                return new ModelDetails { DefaultValue = defaultValue, EntityId = entityId, EntityName = entityName, FieldName = fieldName };
            }
        }

        const string FieldNameFormat = "{0}.{1}";
        const string FieldPrefixFormat = "{0}[{1}]";

        private const string ItemIndexKey = "Localizations_CurrentItemIndex";

        private static IDictionary CachedLocalizations
        {
            get { return HttpContext.Current.Items; }
        }

        private static int CurrentItemIndex
        {
            get
            {
                if (HttpContext.Current.Items[ItemIndexKey] == null)
                    HttpContext.Current.Items[ItemIndexKey] = 0;
                else
                {
                    int index = (int)HttpContext.Current.Items[ItemIndexKey];
                    index++;
                    HttpContext.Current.Items[ItemIndexKey] = index;
                }
                return (int)HttpContext.Current.Items[ItemIndexKey];
            }
        }

        public static void GenerateLocalizationsCache<TModel>(TModel model) where TModel : IEnumerable
        {

        }

        public static MvcHtmlString LocalizedTextAreaFor<TModel, TProperty, L>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<L> localizations, string name = null) where TModel : EntityObject, new()
        {
            return htmlHelper.LocalizedInputFor(expression, localizations, TextAreaExtensions.TextArea, name);
        }

        public static MvcHtmlString LocalizedTextBoxFor<TModel, TProperty, L>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<L> localizations, string name = null) where TModel : EntityObject, new()
        {
            return htmlHelper.LocalizedInputFor(expression, localizations, InputExtensions.TextBox, name);
        }

        private static MvcHtmlString LocalizedInputFor<TModel, TProperty, L>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<L> localizations,
            Func<HtmlHelper, string, string, MvcHtmlString> inputRenderDelegate,
            string name = null) where TModel : EntityObject, new()
        {
            string[] languages = Configurator.LoadSettings().Languages.Split(';');
            object a = new object();
            string elementName = name ?? "localizations";
            var model = htmlHelper.ViewData.Model;

            ModelDetails details = ModelDetails.Create(model, expression);

            var param = Expression.Parameter(typeof(L), "l");
            var wherePredicate = Expression.Lambda<Func<L, bool>>(
                Expression.Equal(
                    Expression.MakeMemberAccess(param, typeof(L).GetProperty("FieldName")),
                    Expression.Constant(details.FieldName)), param);

            var keySelector = Expression.Lambda<Func<L, string>>(
                Expression.MakeMemberAccess(param, typeof(L).GetProperty("Language")), param);

            IQueryable<IGrouping<string, L>> localizedModels = model.Localizations(localizations).Where(wherePredicate).GroupBy(keySelector);

            string propertyKey = string.Format("{0}_{1}_{2}", details.EntityName, details.EntityId, details.FieldName);

            string defaultValue = string.Empty;
            if (model != null)
                defaultValue = expression.Compile().Invoke(model) as string;
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(stringWriter);

            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            bool first = true;

            foreach (string lang in languages)
            {
                WriteLangLink(writer, lang, propertyKey, first);
                first = false;
            }

            first = true;

            foreach (string lang in languages)
            {
                string namePrefix = string.Format(FieldPrefixFormat, elementName, CurrentItemIndex);
                writer.AddAttribute(HtmlTextWriterAttribute.Rel, lang);
                if (!first)
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
                writer.AddAttribute("data-localization-for", propertyKey);
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                string textBoxName = string.Format(FieldNameFormat, namePrefix, "Text");
                string value = null;
                if (localizedModels.Any(lm => lm.Key == lang))
                {
                    dynamic item = localizedModels.First(lm => lm.Key == lang).First();
                    value = (string)item.Text;
                }
                value = value ?? defaultValue;
                writer.WriteHiddens(details, htmlHelper, lang, namePrefix);
                writer.Write(inputRenderDelegate(htmlHelper, textBoxName, value));
                writer.RenderEndTag();
                first = false;
            }

            writer.RenderEndTag();
            MvcHtmlString result = MvcHtmlString.Create(stringWriter.ToString());
            return result;
        }


        static void WriteHiddens(this HtmlTextWriter writer, ModelDetails details, HtmlHelper htmlHelper, string language, string namePrefix, string elementName = "localizations")
        {
            string hiddenFieldName = string.Format(FieldNameFormat, namePrefix, "FieldName");
            string hiddenEntityId = string.Format(FieldNameFormat, namePrefix, "EntityId");
            string hiddenLangId = string.Format(FieldNameFormat, namePrefix, "Language");
            string hiddenEntityName = string.Format(FieldNameFormat, namePrefix, "EntityName");

            writer.Write(htmlHelper.Hidden(hiddenEntityId, details.EntityId));
            writer.Write(htmlHelper.Hidden(hiddenFieldName, details.FieldName));
            writer.Write(htmlHelper.Hidden(hiddenLangId, language));
            writer.Write(htmlHelper.Hidden(hiddenEntityName, details.EntityName));
        }

        static void WriteLangLink(this HtmlTextWriter writer, string language, string propertyKey, bool first)
        {
            string linkClass = "localization";
            if (first)
                linkClass += " current";

            writer.AddAttribute(HtmlTextWriterAttribute.Class, linkClass);
            writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
            writer.AddAttribute(HtmlTextWriterAttribute.Rel, language);
            writer.AddAttribute("data-localization-for", propertyKey);
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write(language);
            writer.RenderEndTag();
            writer.Write("&nbsp;");
        }

    }
}