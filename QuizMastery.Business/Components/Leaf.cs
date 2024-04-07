namespace QuizMastery.Business.Components;

public class Leaf(string component, string name) : IComponent
{
    private readonly string _component = component;
    private readonly string _name = name;

    public object ConvertIntoJson()
    {
        var json = new Dictionary<string, object>
        {
            [_name] = _component
        };

        return json;
    }
}
