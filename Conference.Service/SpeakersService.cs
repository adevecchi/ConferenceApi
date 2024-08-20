using Conference.Data;
using Conference.Domain.Entities;

namespace Conference.Service;

public class SpeakersService : ISpeakersService
{
    private readonly ISpeakersRepository speakersRepository;

    public SpeakersService(ISpeakersRepository speakersRepository)
    {
        this.speakersRepository = speakersRepository;
    }

    public Speaker Add(Speaker speaker)
    {
        return speakersRepository.Add(speaker);
    }

    public bool CheckIfExists(int id)
    {
        return speakersRepository.SpeakerExists(id);
    }

    public bool Delete(Speaker speaker)
    {
        return speakersRepository.Delete(speaker);
    }

    public Speaker Get(int id)
    {
        return speakersRepository.Get(id);
    }

    public IEnumerable<Speaker> GetAll()
    {
        var speakers = speakersRepository.GetAll();
        return speakers;
    }

    public Speaker Update(Speaker speaker)
    {
        return speakersRepository.Update(speaker);
    }
}
