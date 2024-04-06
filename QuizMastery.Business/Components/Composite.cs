namespace QuizMastery.Business.Components;

public class Composite(string component, string name) : IComponent
{
    private readonly string _component = component;
    private readonly string _name = name;
    private readonly List<IComponent> _components = [];

    public object ConvertIntoJson()
    {
        var json = new Dictionary<string, object>
        {
            [_name] = _component
        };

        var components = new List<object>();

        foreach (var component in _components)
        {
            components.Add(component.ConvertIntoJson());
        }

        json["Components"] = components;

        return json;
    }

    public void Add(IComponent component)
    {
        _components.Add(component);
    }
}
