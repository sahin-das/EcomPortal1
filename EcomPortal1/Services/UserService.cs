using EcomPortal.Models.Entities;
using EcomPortal.Models.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EcomPortal.Services
{
    public class UserService
    {
        private readonly ICrudRepository<User> _userRepository;

        public UserService(ICrudRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> CreateAsync(AddUserDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                CreatedDate = DateTime.UtcNow
            };

            return await _userRepository.AddAsync(user);
        }

        public async Task<User> UpdateAsync(Guid id, UpdateUserDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var user = await _userRepository.GetByIdAsync(id) ??
                throw new KeyNotFoundException($"User with ID {id} not found.");
            user.Name = request.Name;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.UpdatedDate = DateTime.UtcNow;

            return await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}