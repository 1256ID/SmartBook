using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Handlers;
using SmartBook.Models;
using SmartBook.Repository;
using SmartBook.Utilities;

namespace SmartBook.Services;

public class UserService
{
    private LibraryRepository _repository;
    public UserService(LibraryRepository repository)
    {
        _repository = repository;
    }
    private List<User> Users => _repository.GetUsers();

    public User GetUser(Guid userId)
        => Users.FirstOrDefault(c => c.Id == userId)
        ?? throw new InvalidOperationException("Ingen användare med angivet " + nameof(userId) + " hittades.");

    public List<User> GetAllUsers() => Users;

    public bool Exists(Guid guid)
    {
        return Users.Any(c => c.Id == guid);
    }

    public bool AnyUserExists()
    {
        return Users.Count != 0;
    }
}
