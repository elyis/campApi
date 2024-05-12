using campapi.src.Domain.Entities.Request;
using campapi.src.Domain.IRepository;
using campapi.src.Domain.Models;
using campapi.src.Infrastructure.Data;
using campApi.src.Domain.Entities.Request;
using campApi.src.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using webApiTemplate.src.App.Provider;

namespace campapi.src.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel?> AddAsync(SignUpBody body, string role)
        {
            var oldUser = await GetAsync(body.Email);
            if (oldUser != null)
                return null;

            var newUser = new UserModel
            {
                Email = body.Email,
                Password = Hmac512Provider.Compute(body.Password),
                RoleName = role,
                Fullname = body.Fullname
            };

            var result = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return result?.Entity;
        }

        public async Task<UserModel?> GetAsync(Guid id)
            => await _context.Users
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<UserModel?> GetAsync(string email)
            => await _context.Users
                .FirstOrDefaultAsync(e => e.Email == email);

        public async Task<UserModel?> UpdateDocument(Guid id, UserDocuments userDocument, string filename)
        {
            var user = await GetAsync(id);
            if (user == null)
                return null;

            switch (userDocument)
            {
                case UserDocuments.SanitaryMinimum:
                    user.SanitaryMinimumFilename = filename;
                    break;

                case UserDocuments.TrainingCertificate:
                    user.TrainingCertificateFilename = filename;
                    break;

                case UserDocuments.VaccinationCertificate:
                    user.VaccinationCertificateFilename = filename;
                    break;

                case UserDocuments.CounselorCertificate:
                    user.CounselorCertificateFilename = filename;
                    break;

                case UserDocuments.CertificateOfNoCriminalRecord:
                    user.CertificateOfNoCriminalRecordFilename = filename;
                    break;

                case UserDocuments.MedicalBook:
                    user.MedicalBookFilename = filename;
                    break;
            }
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel?> UpdateProfileIconAsync(Guid userId, string filename)
        {
            var user = await GetAsync(userId);
            if (user == null)
                return null;

            user.Image = filename;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel?> UpdateProfileInfo(Guid id, UpdatedProfileInfo profileInfo)
        {
            var user = await GetAsync(id);
            if (user == null)
                return null;

            user.HeldPost = profileInfo.HeldPost;
            user.Detachment = profileInfo.Detachment;
            user.Headquarters = profileInfo.Headquarters;
            user.YearOfInitiation = profileInfo.YearOfInitiation;

            await _context.SaveChangesAsync();
            return user;
        }
    }
}