namespace Superi.Features
{
    public class FAQs
    {
        public static FAQList Get()
        {
            return new FAQList(true);
        }

        public static void SetVisibility(int Id, bool Display)
        {
            FAQ faq = new FAQ(Id);
            if (faq.Id > 0)
            {
                faq.Display = Display;
                faq.Save();
            }
        }
        
        public static void Update(int Id, string Name, string Email, string Question, string Answer, bool Display)
        {
            FAQ faq = new FAQ(Id);
            if (faq.Id > 0)
            {
                faq.Display = Display;
                faq.Name = Name;
                faq.Email = Email;
                faq.Question = Question;
                faq.Answer = Answer;
                faq.Save();
            }
        }

        public static void Delete(int Id)
        {
            FAQ faq = new FAQ(Id);
            faq.Remove();
        }

        public static void Insert(string Name, string Email, string Question, string Answer, bool Display)
        {
            FAQ faq = new FAQ();
            faq.Display = Display;
            faq.Name = Name;
            faq.Email = Email;
            faq.Question = Question;
            faq.Answer = Answer;
            faq.Save();
        }
    }
}
