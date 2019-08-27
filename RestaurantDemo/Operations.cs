using System;
using System.Collections.Generic;
using System.Linq;
using static System.DateTime;

namespace RestaurantDemo
{
    public class Operations
    {
        public List<Guest> TodayGuest()
        {
            using (var context = new RestaurantContext())
            {
                context.Configuration.LazyLoadingEnabled = false;

                return context.Guests.ToList();
            }
        }
        /// <summary>
        /// If a guest has a breakfast order return it, if nothing
        /// ordered indicate no order was placed.
        /// </summary>
        /// <param name="guestIdentifier"></param>
        /// <returns></returns>
        public string GuestBreakfastOrderForToday(int guestIdentifier)
        {
            var today = Now.Date;
            using (var context = new RestaurantContext())
            {
                var results =
                (
                    from orderItems in context.BreakfastOrderItems
                    join orderItem in context.BreakfastOrderItems on orderItems.BreakfastItem.ItemIdentifier equals orderItem.ItemIdentifier
                    where orderItem.BreakfastOrder.OrderDate == today && 
                          orderItem.GuestIdentifier == guestIdentifier
                    select orderItem
                ).ToList();

                if (results.Count >0)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    var room = context.Guests
                        .FirstOrDefault(g => g.GuestIdentifier == guestIdentifier).Room;

                    return string.Join(Environment.NewLine, results
                               .Select(item => item.BreakfastItem.Item).ToArray()) + 
                           $"\n\nRoom: {room.RoomDesginator}{room.RoomNumber}";
                }
                else
                {
                    return "No order placed";
                }
            }
        }
    }
}
