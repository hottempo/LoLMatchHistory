using LoLMatchHistory.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LoLMatchHistory.Infrastructure.Repositories;
public class MatchInfoRepository(LoLMatchHistoryContext context)
{
    private readonly LoLMatchHistoryContext _context = context;

    public IQueryable<MatchInfo> GetAll()
    {
        return _context.Matches
            .AsNoTracking()
            .AsSplitQuery()
            .Include(m => m.Bans)
            .Include(m => m.Kills)
            .Include(m => m.Gold)
            .Include(m => m.Structures)
            .Include(m => m.Monsters);

    // return result;


        }





        /// <summary>
        /// I don't get it. This is way too slow to be useable!
        /// </summary>
        /// <returns></returns>
        /*public IQueryable<MatchInfo> GetAllCombined()
        {
            return _context.Matches
                .Include(m => m.Bans)
                .Include(m => m.Kills)
                .Include(m => m.Gold)
                .Include(m => m.Structures)
                .Include(m => m.Monsters)
                .AsNoTracking()
                .AsSplitQuery();

            // return result;
        }*/

    public IQueryable<MatchInfoOptimizedView> GetAllOptimized()
    {
        return _context.MatchInfoOptimized
            .AsNoTracking();
    }


    public IQueryable<MatchInfo> GetMatchesByPlayer(string playerName)
    {
        /*var result = _context.Matches
            .Where(m => m.BlueTop.Equals(playerName) ||
                m.BlueJungle.Equals(playerName) ||
                m.BlueMiddle.Equals(playerName) ||
                m.BlueADC.Equals(playerName) ||
                m.BlueSupport.Equals(playerName) ||
                m.RedTop.Equals(playerName) ||
                m.RedJungle.Equals(playerName) ||
                m.RedMiddle.Equals(playerName) ||
                m.RedADC.Equals(playerName) ||
                m.RedSupport.Equals(playerName)
            )
            .AsNoTracking()
            .AsSplitQuery()
            .Include(m => m.Bans)
            .Include(m => m.Kills)
            .Include(m => m.Gold)
            .Include(m => m.Structures)
            .Include(m => m.Monsters);

        return result;
        
         
         */

        return _context.Matches
            .Where(m =>
                new[]
                {
                    m.BlueTop, m.BlueJungle, m.BlueMiddle, m.BlueADC, m.BlueSupport,
                    m.RedTop, m.RedJungle, m.RedMiddle, m.RedADC, m.RedSupport
                }.Contains(playerName)
            )
            .AsNoTracking()
            .AsSplitQuery()
            .Include(m => m.Bans)
            .Include(m => m.Kills)
            .Include(m => m.Gold)
            .Include(m => m.Structures)
            .Include(m => m.Monsters);

    }
}
