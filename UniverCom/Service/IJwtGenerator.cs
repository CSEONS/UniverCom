using UniverCom.Domain.Entities;

namespace UniverCom.Service
{
    public interface IJwtGenerator
    {
        string Generate(AppUser user, TimeSpan timeSpan);
    }
}