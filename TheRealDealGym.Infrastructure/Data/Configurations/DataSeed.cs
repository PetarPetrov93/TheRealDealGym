using Microsoft.AspNetCore.Identity;
using TheRealDealGym.Infrastructure.Data.Models;
using static TheRealDealGym.Infrastructure.Constants.CustomClaims;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    public class DataSeed
    {
        public DataSeed()
        {
            SeedUsers();
            SeedTrainers();
            SeedSports();
            SeedRooms();
            SeedClasses();
            SeedBookings();
            SeedJobAdverts();
        }

        public ApplicationUser AdminUser {  get; set; }
        public IdentityUserClaim<Guid> AdminUserClaim { get; set; }

        public ApplicationUser TrainerUserFighting { get; set; }
        public IdentityUserClaim<Guid> TrainerUserFightingClaim { get; set; }
        public ApplicationUser TrainerUserWater { get; set; }
        public IdentityUserClaim<Guid> TrainerUserWaterClaim { get; set; }
        public ApplicationUser TrainerUserStretching { get; set; }
        public IdentityUserClaim<Guid> TrainerUserStretchingClaim { get; set; }

        public ApplicationUser GuestUserBooked { get; set; }
        public IdentityUserClaim<Guid> GuestUserBookedClaim { get; set; }
        public ApplicationUser GuestUserNotBooked { get; set; }
        public IdentityUserClaim<Guid> GuestUserNotBookedClaim { get; set; }

        public Trainer AdminTrainer { get; set; }

        public Trainer FightingTrainer { get; set; }
        public Trainer WaterTrainer { get; set; }
        public Trainer StretchingTrainer { get; set; }

        public Sport MuayThai { get; set; }
        public Sport Swimming { get; set; }
        public Sport Yoga { get; set; }

        public Room FightingRoom { get; set; }
        public Room Pool { get; set; }
        public Room OpenSpaceRoom { get; set; }

        public Class MuayThaiBeginners { get; set; }
        public Class SwimmingForKids {  get; set; }
        public Class YogaAdvanced { get; set; }


        public Booking BookingMuayThai { get; set; }

        public JobAdvert JobAdvertActive { get; set; }
        public JobAdvert JobAdvertInactive { get; set; }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            //ASP User for Admin
            AdminUser = new ApplicationUser()
            {
                Id = new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584"),
                UserName = "admin@trdg.com",
                NormalizedUserName = "ADMIN@TRDG.COM",
                Email = "admin@trdg.com",
                NormalizedEmail = "ADMIN@TRDG.COM",
                FirstName = "Admin",
                LastName = "Adminov"
            };

            AdminUserClaim = new IdentityUserClaim<Guid>()
            {
                Id = 1,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Admin Adminov",
                UserId = Guid.Parse("42b0f438-188e-4a5c-b379-e6256e6f4584")
            };

            AdminUser.SecurityStamp = "62f2b46f-f90f-44bb-94fd-9cd7fc523047";

            AdminUser.PasswordHash =
                 hasher.HashPassword(AdminUser, "123456");

            // ASP Users for Trainers
            TrainerUserFighting = new ApplicationUser()
            {
                Id = new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                UserName = "FightingTrainer@trdg.com",
                NormalizedUserName = "FIGHTINGTRAINER@TRDG.COM",
                Email = "FightingTrainer@trdg.com",
                NormalizedEmail = "FIGHTINGTRAINER@TRDG.COM",
                FirstName = "Trainer",
                LastName = "Gae"
            };

            TrainerUserFightingClaim = new IdentityUserClaim<Guid>()
            {
                Id = 2,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Trainer Gae",
                UserId = Guid.Parse("dea12856-c198-4129-b3f3-b893d8395082")
            };

            TrainerUserFighting.SecurityStamp = "78f47fd7-d3d5-4fa4-bedc-e1ce253f5f6f";

            TrainerUserFighting.PasswordHash =
                 hasher.HashPassword(TrainerUserFighting, "123456");


            TrainerUserWater = new ApplicationUser()
            {
                Id = new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"),
                UserName = "WaterTrainer@trdg.com",
                NormalizedUserName = "WATERTRAINER@TRDG.COM",
                Email = "WaterTrainer@trdg.com",
                NormalizedEmail = "WATERTRAINER@TRDG.COM",
                FirstName = "Michael",
                LastName = "Phelps"
            };

            TrainerUserWaterClaim = new IdentityUserClaim<Guid>()
            {
                Id = 3,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Michael Phelps",
                UserId = Guid.Parse("c85209a1-3dec-4171-a17c-0d5203286df4")
            };

            TrainerUserWater.SecurityStamp = "0cecaf15-dc12-427f-8118-5f537802d729";

            TrainerUserWater.PasswordHash =
                 hasher.HashPassword(TrainerUserWater, "123456");


            TrainerUserStretching = new ApplicationUser()
            {
                Id = new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                UserName = "StretchingTrainer@trdg.com",
                NormalizedUserName = "STRETCHINGTRAINER@TRDG.COM",
                Email = "StretchingTrainer@trdg.com",
                NormalizedEmail = "STRETCHINGTRAINER@TRDG.COM",
                FirstName = "Katie",
                LastName = "Thompson"
            };

            TrainerUserStretchingClaim = new IdentityUserClaim<Guid>()
            {
                Id = 4,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Katie Thompson",
                UserId = Guid.Parse("06c362f9-c953-4507-a4ba-f53bd9e920f9")
            };

            TrainerUserStretching.SecurityStamp = "5160ac97-f58f-479a-9d26-6b1caa75bad5";

            TrainerUserStretching.PasswordHash =
                 hasher.HashPassword(TrainerUserStretching, "123456");

            //ASP Users for Non-trainers
            GuestUserBooked = new ApplicationUser()
            {
                Id = new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"),
                UserName = "firstGuest@trdg.com",
                NormalizedUserName = "FIRSTGUEST@TRDG.COM",
                Email = "firstGuest@trdg.com",
                NormalizedEmail = "FIRSTGUEST@TRDG.COM",
                FirstName = "Pete",
                LastName = "Johnson"
            };

            GuestUserBookedClaim = new IdentityUserClaim<Guid>()
            {
                Id = 5,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Pete Johnson",
                UserId = Guid.Parse("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef")
            };

            GuestUserBooked.SecurityStamp = "e7326130-1924-49a0-9912-e1f874200182";

            GuestUserBooked.PasswordHash =
            hasher.HashPassword(GuestUserBooked, "123456");


            GuestUserNotBooked = new ApplicationUser()
            {
                Id = new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"),
                UserName = "secondGuest@trdg.com",
                NormalizedUserName = "SECONDGUEST@TRDG.COM",
                Email = "secondGuest@trdg.com",
                NormalizedEmail = "SECONDGUEST@TRDG.COM",
                FirstName = "Stella",
                LastName = "Clay"
            };

            GuestUserNotBookedClaim = new IdentityUserClaim<Guid>()
            {
                Id = 6,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Stella Clay",
                UserId = Guid.Parse("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a")
            };

            GuestUserNotBooked.SecurityStamp = "bae0779c-fe46-4361-a8b4-2e5e5b705e64";

            GuestUserNotBooked.PasswordHash =
            hasher.HashPassword(GuestUserNotBooked, "123456");
        }

        private void SeedTrainers()
        {
            AdminTrainer = new Trainer()
            {
                Id = new Guid("1d674a7f-78ca-42f0-96a3-856cb26fb7c3"),
                Age = 37,
                YearsOfExperience = 15,
                Bio = "I am one of the best admins in the world! Nobody is better than me!",
                UserId = Guid.Parse("42b0f438-188e-4a5c-b379-e6256e6f4584")
            };

            FightingTrainer = new Trainer()
            {
                Id = new Guid("966d1ddc-b505-4aae-b790-595a4c688931"),
                Age = 51,
                YearsOfExperience = 25,
                Bio = "I am one of the best MyaiThai coaches in the world",
                UserId = Guid.Parse("dea12856-c198-4129-b3f3-b893d8395082")
            };

            WaterTrainer = new Trainer()
            {
                Id = new Guid("3c944adc-2b2b-4e81-a643-643fcb116262"),
                Age = 40,
                YearsOfExperience = 19,
                Bio = "I am one of the best swimmers in the world",
                UserId = Guid.Parse("c85209a1-3dec-4171-a17c-0d5203286df4")
            };

            StretchingTrainer = new Trainer()
            {
                Id = new Guid("62cf1550-e01e-452b-9fe4-95487b14514e"),
                Age = 24,
                YearsOfExperience = 3,
                Bio = "I am very positive person and great professional.",
                UserId = Guid.Parse("06c362f9-c953-4507-a4ba-f53bd9e920f9")
            };
        }

        public void SeedSports()
        {
            MuayThai = new Sport()
            {
                Id = new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b"),
                Title = "MuayThai"
            };

            Swimming = new Sport()
            {
                Id = new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"),
                Title = "Swimming"
            };

            Yoga = new Sport()
            {
                Id = new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"),
                Title = "Yoga"
            };
        }

        public void SeedRooms()
        {
            FightingRoom = new Room()
            {
                Id = new Guid("3db85752-7746-4d29-a638-5a54c2e07075"),
                Type = "Fighting room",
                Capacity = 50
            };

            Pool = new Room()
            {
                Id = new Guid("70e053fc-61a0-4ab7-9104-08572c23aa38"),
                Type = "Pool",
                Capacity = 40
            };

            OpenSpaceRoom = new Room()
            {
                Id = new Guid("d88e930f-8694-4c04-a58a-ca71373b6c22"),
                Type = "Open Space room",
                Capacity = 1 //for testing purposes it has to be low 
            };
        }

        public void SeedClasses()
        {
            MuayThaiBeginners = new Class()
            {
                Id = new Guid("86cc93b0-3993-4a88-b41c-c0414538c7f4"),
                Title = "Muay Thai for beginners",
                Description = "This is a Muay Thai class suitable for beginners.",
                DateAndTime = new DateTime(2025, 10, 5, 10, 0, 0),
                Price = 15,
                TrainerId = Guid.Parse("966d1ddc-b505-4aae-b790-595a4c688931"),
                SportId = Guid.Parse("28b80b07-87c8-42f7-9af6-28d832ce7b2b"),
                RoomId = Guid.Parse("3db85752-7746-4d29-a638-5a54c2e07075")
            };

            SwimmingForKids = new Class()
            {
                Id = new Guid("6a05950a-e1bf-4b6c-9577-2c289c3e6de6"),
                Title = "Swimming for kids",
                Description = "This is a swimming class for children only.",
                DateAndTime = new DateTime(2025, 9, 22, 9, 0, 0),
                Price = 10,
                TrainerId = Guid.Parse("3c944adc-2b2b-4e81-a643-643fcb116262"),
                SportId = Guid.Parse("7e20cc5c-6c1b-4ba6-a070-517660fead98"),
                RoomId = Guid.Parse("70e053fc-61a0-4ab7-9104-08572c23aa38")
            };

            YogaAdvanced = new Class()
            {
                Id = new Guid("7a90a874-0c11-4e70-9391-cc3487e60b0e"),
                Title = "Yoga Advanced",
                Description = "This is a Yoga class suitable experienced people with at least 1 year of experience in yoga/stretching.",
                DateAndTime = new DateTime(2025, 3, 3, 13, 0, 0),
                Price = 14,
                TrainerId = Guid.Parse("62cf1550-e01e-452b-9fe4-95487b14514e"),
                SportId = Guid.Parse("890d3966-eb5e-42f1-97e2-79382ce3ac96"),
                RoomId = Guid.Parse("d88e930f-8694-4c04-a58a-ca71373b6c22")
            };
        }

        public void SeedBookings()
        {
            BookingMuayThai = new Booking()
            {
                Id = new Guid("2283428d-0ed0-4837-9bb2-028485808ac5"),
                UserId = Guid.Parse("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"),
                ClassId = Guid.Parse("86cc93b0-3993-4a88-b41c-c0414538c7f4")
            };
        }

        public void SeedJobAdverts()
        {
            JobAdvertActive = new JobAdvert()
            {
                Id = new Guid("d53d3db8-5856-48a0-a739-eefd609aee1e"),
                Title = "Fitness coach full time",
                Description = "We are looking for a motivated and experienced fitness coach for a position in our great team."
            };

            JobAdvertInactive = new JobAdvert()
            {
                Id = new Guid("73d5830c-73bc-4d1f-9533-1d44fd4621e5"),
                Title = "CrossFit coach full time",
                Description = "We are looking for a motivated and experienced CrossFit coach for a position in our great team.",
                IsActive = false
            };
        }
    }
}
