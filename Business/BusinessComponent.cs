namespace Reflector.Business
{
    public interface IBusinessComponent
    {
        void SubmitPerson(Person person);
    }

    public class BusinessComponent : IBusinessComponent
    {
        public bool SubmitCalled { get; private set; }

        public Person Person { get; private set; }

        public void SubmitPerson(Person person)
        {
            SubmitCalled = true;
            Person = person;
        }
    }
}