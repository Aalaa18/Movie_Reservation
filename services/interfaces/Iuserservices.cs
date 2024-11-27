using Movie.Models;

namespace Movie.services.interfaces
{
    public interface Iuserservices
    {
        void addusers();
        bool checkAdmin(string name);
        bool checkusers(string name, string pass);
        users GetUsers(string name);
        void RemoveUser(string name);
        void showoptions(string name);
        void start();
    }
}