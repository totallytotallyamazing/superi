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
    public static class LocalizationHelpers
    {
        struct ModelDetails
        {
            public string EntityName;
            public string EntityId;
            public string FieldName;
            public string DefaultValue;

            public static ModelDetails Create<TModel, TProperty>(TModel model, Expression<Func<TModel, TProperty>> expression)
            {
                string entityName = typeof(TModel).Name;
                string entityId = ((dynamic)model).Id.ToString();
                string fieldName = (expression.Body as MemberExpression).Member.Name;
                string defaultValue = expression.Compile().Invoke(model).ToString();

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

        public static MvcHtmlString LocalizedTextBox<TModel, TProperty, L>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<L> localizations, string name = null) where TModel : EntityObject, new()
        {
            string[] languages = Configurator.LoadSettings().Languages.Split(';');
            object a = new object();
            string elementName = name ?? "localizations";
            var model = (htmlHelper.ViewData.Model as TModel);
            IDictionary<string, TModel> localizedModels = model.Localizations(localizations);

            ModelDetails details = ModelDetails.Create(model, expression);

            string namePrefix = string.Format(FieldPrefixFormat, elementName, CurrentItemIndex);
            string defaultValue = expression.Compile().Invoke(model).ToString();
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
            
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            bool first = true;

            foreach (string lang in languages)
            {
                WriteLangLink(writer, lang);
            }

            foreach (string  lang in languages)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Rel, lang);
                if (!first)
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                string textBoxName = string.Format(FieldNameFormat, namePrefix, "Text");
                string value = null;
                if (localizedModels[lang] != null)
                {
                    TModel item = localizedModels[lang];
                    PropertyInfo info = typeof(TModel).GetProperty(details.FieldName, BindingFlags.Public);
                    value = (string)info.GetValue(item, null);
                }
                value = value ?? defaultValue;
                writer.WriteHiddens(details, htmlHelper, lang);
                writer.Write(htmlHelper.TextBox(textBoxName, value));
                writer.RenderEndTag();
                first = false;
            }

            writer.RenderEndTag();
            MvcHtmlString result = MvcHtmlString.Create(stringWriter.ToString());
            return result;
        }

        static void WriteHiddens(this HtmlTextWriter writer, ModelDetails details, HtmlHelper htmlHelper, string language, string elementName = "localizations")
        {
            string namePrefix = string.Format(FieldPrefixFormat, elementName, CurrentItemIndex);

            string hiddenFieldName = string.Format(FieldNameFormat, namePrefix, "FieldName");
            string hiddenEntityId = string.Format(FieldNameFormat, namePrefix, "EntityId");
            string hiddenLangId = string.Format(FieldNameFormat, namePrefix, "Language");
            string hiddenEntityName = string.Format(FieldNameFormat, namePrefix, "EntityName");

            writer.Write(htmlHelper.Hidden(hiddenEntityId, details.EntityId));
            writer.Write(htmlHelper.Hidden(hiddenFieldName, details.FieldName));
            writer.Write(htmlHelper.Hidden(hiddenLangId, language));
            writer.Write(htmlHelper.Hidden(hiddenEntityName, details.EntityName));
        }

        static void WriteLangLink(this HtmlTextWriter writer, string language)
        {
                writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
                writer.AddAttribute(HtmlTextWriterAttribute.Rel, language);
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write(language);
                writer.RenderEndTag();
                writer.Write("&nbsp;");
        }

    }
}