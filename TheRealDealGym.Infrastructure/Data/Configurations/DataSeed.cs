using Microsoft.AspNetCore.Identity;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    public class DataSeed
    {
        public DataSeed()
        {
            SeedUsers();
            SeedTrainers();
            SeedSports();
            SeedTrainersSports();
            SeedRooms();
            SeedClasses();
            SeedBookings();
        }

        public ApplicationUser TrainerUserFighting { get; set; }
        public ApplicationUser TrainerUserWater { get; set; }
        public ApplicationUser TrainerUserStretching { get; set; }

        public ApplicationUser GuestUserBooked { get; set; }
        public ApplicationUser GuestUserNotBooked { get; set; }

        public Trainer FightingTrainer { get; set; }
        public Trainer WaterTrainer { get; set; }
        public Trainer StretchingTrainer { get; set; }

        public Sport MuayThai { get; set; }
        public Sport Swimming { get; set; }
        public Sport Yoga { get; set; }

        public TrainerSport TrainerFighting { get; set; }
        public TrainerSport TrainerWater {  get; set; }
        public TrainerSport TrainerStretching { get; set; }

        public Room FightingRoom { get; set; }
        public Room Pool { get; set; }
        public Room OpenSpaceRoom { get; set; }

        public Class MuayThaiBeginners { get; set; }
        public Class SwimmingForKids {  get; set; }
        public Class YogaAdvanced { get; set; }


        public Booking BookingMuayThai { get; set; }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

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

            GuestUserNotBooked.SecurityStamp = "bae0779c-fe46-4361-a8b4-2e5e5b705e64";

            GuestUserNotBooked.PasswordHash =
            hasher.HashPassword(GuestUserNotBooked, "123456");
        }

        private void SeedTrainers()
        {
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
                Title = "MuayThai",
                Category = "FightingSports"
            };

            Swimming = new Sport()
            {
                Id = new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"),
                Title = "Swimming",
                Category = "WaterSports"
            };

            Yoga = new Sport()
            {
                Id = new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"),
                Title = "Yoga",
                Category = "Stretching"
            };
        }

        public void SeedTrainersSports()
        {
            TrainerFighting = new TrainerSport()
            {
                TrainerId = Guid.Parse("966d1ddc-b505-4aae-b790-595a4c688931"),
                SportId = Guid.Parse("28b80b07-87c8-42f7-9af6-28d832ce7b2b")
            };

            TrainerWater = new TrainerSport()
            {
                TrainerId = Guid.Parse("3c944adc-2b2b-4e81-a643-643fcb116262"),
                SportId = Guid.Parse("7e20cc5c-6c1b-4ba6-a070-517660fead98")
            };

            TrainerStretching = new TrainerSport()
            {
                TrainerId = Guid.Parse("62cf1550-e01e-452b-9fe4-95487b14514e"),
                SportId = Guid.Parse("890d3966-eb5e-42f1-97e2-79382ce3ac96")
            };
        }

        public void SeedRooms()
        {
            FightingRoom = new Room()
            {
                Id = new Guid("3db85752-7746-4d29-a638-5a54c2e07075"),
                Name = "Fighting room",
                Capacity = 50
            };

            Pool = new Room()
            {
                Id = new Guid("70e053fc-61a0-4ab7-9104-08572c23aa38"),
                Name = "Pool",
                Capacity = 40
            };

            OpenSpaceRoom = new Room()
            {
                Id = new Guid("d88e930f-8694-4c04-a58a-ca71373b6c22"),
                Name = "Open Space room",
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
    }
}
