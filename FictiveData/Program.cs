using Application.Interfaces;
using Application.Services;
using Domain.Entity;
using Persistence.Repositories;
using System.Runtime.CompilerServices;

namespace FictiveData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IChallengeRepository repo = new ChallengeRepository();
            ChallengeManager cm = new ChallengeManager(repo);
            IUserRepository userRepository = new UserRepository();
            UserManager userManager = new UserManager(userRepository);

            List<Prize> prizes = new List<Prize>
        {
            new Prize("logo1.jpg", "Premium Cookware Set", "Upgrade your kitchen with high-quality cookware.", "Kitchen Essentials Co."),
            new Prize("logo2.jpg", "Farmers' Market Shopping Spree", "Enjoy fresh produce with a gift card from the local farmers' market.", "Fresh Harvest Market"),
            new Prize("logo3.jpg", "Baking Essentials Kit", "Equip yourself with the essential tools for baking.", "Bake Master Co."),
            new Prize("logo4.jpg", "Nutrition Consultation", "Receive personalized advice for healthy snacking.", "Healthy Living Consultants"),
            new Prize("logo5.jpg", "Cookbook Collection", "Expand your cookbook collection with inspiring recipes.", "Culinary Press"),
        };
            List<Challenge> foodChallenges = new List<Challenge>
        {
            new Challenge("Spicy Wings Challenge", "Eat a dozen of the spiciest wings in under 10 minutes.", "spicy_wings.jpg", prizes, DateTime.Now.AddMonths(-1)),
            new Challenge("Giant Burger Challenge", "Finish a massive burger with at least 5 patties and a pound of fries.", "giant_burger.jpg", prizes, DateTime.Now.AddMonths(-2)),
             new Challenge("Spicy Pizza Challenge", "Conquer a large pizza loaded with the hottest peppers and spices.", "spicy_pizza.jpg", prizes, DateTime.Now.AddMonths(-3)),
            new Challenge("Monster Burrito Challenge", "Devour a giant burrito weighing at least 5 pounds within 15 minutes.", "monster_burrito.jpg", prizes, DateTime.Now.AddMonths(-4)),
            new Challenge("Extreme Milkshake Challenge", "Finish an enormous milkshake with all the toppings and extras.", "extreme_milkshake.jpg", prizes, DateTime.Now.AddMonths(5)),
            new Challenge("Chili Pepper Eating Contest", "Eat as many chili peppers as you can in 5 minutes without drinking anything.", "chili_pepper_contest.jpg", prizes, DateTime.Now.AddMonths(6)),
            new Challenge("Jumbo Ice Cream Sundae Challenge", "Enjoy a massive ice cream sundae with at least 10 different flavors and toppings.", "jumbo_ice_cream_sundae.jpg", prizes, DateTime.Now.AddMonths(7)),
            new Challenge("Colossal Nachos Challenge", "Finish a mountain of loaded nachos with all the fixings.", "colossal_nachos.jpg", prizes, DateTime.Now.AddMonths(8)),
            new Challenge("Epic Donut Tower Challenge", "Consume a towering stack of oversized donuts within a time limit.", "epic_donut_tower.jpg", prizes, DateTime.Now.AddMonths(9)),
            new Challenge("Sizzling Steak Challenge", "Finish a massive steak weighing at least 2 kilograms in under 20 minutes.", "sizzling_steak.jpg", prizes, DateTime.Now.AddMonths(10))
        };
            List<User> users = new List<User>
            {
            new User("lydiasmith84@email.com", "Lydia", "Smith"),
            new User("marcus.reynolds22@email.com", "Marcus", "Reynolds"),
            new User("bella.chang99@email.com", "Isabella", "Chang"),
            new User("thompson.noah77@email.com", "Noah", "Thompson"),
            new User("ava.rodriguez123@email.com", "Ava", "Rodriguez"),
            new User("e.patelpatel@email.com", "Ethan", "Patel"),
            new User("m.williams22@email.com", "Mia", "Williams"),
            new User("alex.nguyen88@email.com", "Alexander", "Nguyen"),
            new User("s.brownie45@email.com", "Sophia", "Brown"),
            new User("daniel_garcia@email.com", "Daniel", "Garcia")
        };

            foreach (var item in foodChallenges)
            {
                cm.AddChallenge(item);
            }
            foreach (var user in users)
            {
                userManager.AddUser(user);
            }
        }
    }
}