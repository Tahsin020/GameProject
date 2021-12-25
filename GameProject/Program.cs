using GameProject.Abstract;
using GameProject.Adapters;
using GameProject.Concrete;
using GameProject.Entities;
using System;
using System.Collections.Generic;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Member member = new Member
            {
                MemberId = 1,
                FirstName = "Tahsin",
                LastName = "IŞIK",
                DateOfBirth = new DateTime(2002,06,23),
                NationalityId = "30092139838"
            };

            Campaign campaign = new Campaign
            {
                CampaignId = 1,
                CampignName = "Kampanya 1",
                CampaignType = "Kış"
            };

            Game game = new Game
            {
                GameId = 1,
                GameName = "Call of Duty"
            };

            List<IOrderEntity> salesList = new List<IOrderEntity> { member, game, campaign };

            MemberManager memberManager = new MemberManager(new MernisServiceAdapter());
            memberManager.Add(new Member
            {
                MemberId = 2,
                FirstName = "Hamza",
                LastName = "Koy",
                DateOfBirth = new DateTime(1999, 1, 1),
                NationalityId = "11111111111"
            });

            memberManager.Update(member);
            memberManager.Delete(member);

            CampaignManager campaignManager = new CampaignManager();
            campaignManager.Add(new Campaign
            {
                CampaignId = 2,
                CampignName = "Kampanya 2",
                CampaignType = "Bahar"
            });

            campaignManager.Update(campaign);
            campaignManager.Delete(campaign);

            GameManager gameManager = new GameManager();
            gameManager.Add(new Game
            {
                GameId = 2,
                GameName = "Metin 2"
            });

            gameManager.Update(game);
            gameManager.Delete(game);

            OrderManager orderManager = new OrderManager();
            orderManager.Sale(salesList);
        }
    }
}
