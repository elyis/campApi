using campapi.src.Domain.Entities.Request;
using campapi.src.Domain.Models;
using campApi.src.Domain.Entities.Request;
using campApi.src.Domain.Enums;

namespace campapi.src.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<UserModel?> AddAsync(SignUpBody body, string role);
        Task<UserModel?> GetAsync(Guid id);
        Task<UserModel?> GetAsync(string email);
        Task<UserModel?> UpdateProfileIconAsync(Guid userId, string filename);
        Task<UserModel?> UpdateProfileInfo(Guid id, UpdatedProfileInfo profileInfo);
        Task<UserModel?> UpdateDocument(Guid id, UserDocuments userDocument, string filename);
    }
}