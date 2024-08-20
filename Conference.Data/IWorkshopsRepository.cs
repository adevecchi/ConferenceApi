using Conference.Domain.Entities;

namespace Conference.Data;
 
public interface IWorkshopsRepository
{
    Workshop Add(Workshop workshop);

    IQueryable<Workshop> GetAll();

    Workshop Get(int id);

    Workshop Update(Workshop workshop);

    bool Delete(Workshop workshop);

    bool WorkshopExists(int id);

    List<Workshop> GetWorkshopsForSpeaker(int speakerId);
    
    Workshop GetWorkshop(int speakerId, int workshopId);
}
