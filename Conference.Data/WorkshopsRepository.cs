using Conference.Domain.Entities;

namespace Conference.Data;

public class WorkshopsRepository : IWorkshopsRepository
{
    private readonly ConferenceContext context;

    public WorkshopsRepository(ConferenceContext context)
    {
        this.context = context;
    }

    public Workshop Add(Workshop workshop)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Workshop workshop)
    {
        throw new NotImplementedException();
    }

    public Workshop Get(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Workshop> GetAll()
    {
        throw new NotImplementedException();
    }


    public bool WorkshopExists(int id)
    {
        throw new NotImplementedException();
    }

    public Workshop Update(Workshop workshop)
    {
        throw new NotImplementedException();
    }

    public Workshop GetWorkshop(int speakerId, int workshopId)
    {
        return context.Workshops.FirstOrDefault(x => x.SpeakerId == speakerId && x.Id == workshopId);
    }

    public Workshop GetWorkshop(int workshopId)
    {
        return context.Workshops.FirstOrDefault(x => x.Id == workshopId);
    }

    public List<Workshop> GetWorkshopsForSpeaker(int speakerId)
    {
        if (speakerId == 0)
        {
            throw new ArgumentNullException(nameof(speakerId));
        }

        return context.Workshops
            .Where(x => x.SpeakerId == speakerId)
            .OrderBy(x => x.Id).ToList();
    }
}
