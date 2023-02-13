namespace Service.Helpers
{
    public class ReverseText
    {
        public string ReverseString(string text)
        {
            char[] charText = text.ToCharArray();
            Array.Reverse(charText);

            return new string(charText);
        }
    }
}
