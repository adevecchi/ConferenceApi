using Conference.Domain.Entities;

namespace Conference.Service;

public interface ISpeakersService
{
    Speaker Add(Speaker speaker);

    IEnumerable<Speaker> GetAll();

    Speaker Get(int id);

    Speaker Update(Speaker speaker);

    bool Delete(Speaker speaker);

    bool CheckIfExists(int id);
}
