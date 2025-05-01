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

    public User GetUser(Guid userId)
        => GetUsers().FirstOrDefault(c => c.Id == userId)
        ?? throw new InvalidOperationException("Ingen användare med angivet " + nameof(userId) + " hittades.");

    public List<User> GetUsers() => _repository.GetUsers();

    public void AddUser(User user)
    {
        _repository.Add(user);
    }

    public void Remove(User user)
    {
        throw new NotImplementedException();
    }

    // Övriga metoder

    public bool Exists(Guid guid)
    {
        return GetUsers().Any(c => c.Id == guid);
    }

   


    public bool AnyUserExists()
    {
        return GetUsers().Count != 0;
    }

    

}

   
