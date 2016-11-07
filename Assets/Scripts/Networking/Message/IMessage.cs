public interface IMessage
{
    MessageSubject subject { get; }
    string[] raw { get; }
}