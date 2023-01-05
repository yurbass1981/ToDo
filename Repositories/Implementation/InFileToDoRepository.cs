using System.Xml.Serialization;
using ToDo.DTOs;

namespace ToDo.Repositories.Implementation;

public class InFileToDoRepository : IToDoRepository
{
    public void Create(TodoItemDto toDoItem)
    {
        List<TodoItemDto> todoItemList;

        using (var streamReader = new StreamReader("Resources/data_storage.xml"))
        {
            var serializer = new XmlSerializer(typeof(List<TodoItemDto>));
            todoItemList = serializer.Deserialize(streamReader) as List<TodoItemDto>;
        }

        todoItemList.Add(toDoItem);

        using (var streamWriter = new StreamWriter("Resources/data_storage.xml"))
        {
            var serializer = new XmlSerializer(typeof(List<TodoItemDto>));
            serializer.Serialize(streamWriter, todoItemList);
        }
    }

    public void Delete(Guid id)
    {
        List<TodoItemDto> todoItemList;

        using (var streamReader = new StreamReader("Resources/data_storage.xml"))
        {
            var serializer = new XmlSerializer(typeof(List<TodoItemDto>));
            todoItemList = serializer.Deserialize(streamReader) as List<TodoItemDto>;
        }

        //TODO:

        using (var streamWriter = new StreamWriter("Resources/data_storage.xml"))
        {
            var serializer = new XmlSerializer(typeof(List<TodoItemDto>));
            serializer.Serialize(streamWriter, todoItemList);
        }

        throw new NotImplementedException();
    }

    public TodoItemDto GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<TodoItemDto> GetList()
    {
        List<TodoItemDto> todoItemList;

        using (var streamReader = new StreamReader("Resources/data_storage.xml"))
        {
            var serializer = new XmlSerializer(typeof(List<TodoItemDto>));
            todoItemList = serializer.Deserialize(streamReader) as List<TodoItemDto>;
        }

        return todoItemList;
    }

    public void Update(Guid id, TodoItemDto toDoItem)
    {
        throw new NotImplementedException();
    }
}