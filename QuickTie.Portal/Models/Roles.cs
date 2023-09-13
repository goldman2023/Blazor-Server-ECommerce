using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;

namespace QuickTie.Portal.Models
{
    public class Roles
    {
        public static readonly string AdministratorsRole = "Administrators";
        public static readonly string SalesManagersRole = "SalesManagers";
        public static readonly string SalesRep = "Sales";
        public static readonly string SuperAdmin = "SuperAdmin";
    }

    public partial class QuickTieRole : MongoRole
    {
        public override ObjectId Id { get; set; }
    }
}
