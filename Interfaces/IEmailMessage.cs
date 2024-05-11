namespace DB_993.Interfaces
{
    internal interface IEmailMessage
    {
        public void PushEmailMessage(string email, int idComp);
        public void PushEmailMessage(string email, string r);
    }
}
