using GameFramework.Command;

namespace M2Server
{
    [GameCommand("TestFire", "", 10)]
    public class TestFireCommand : BaseCommond
    {
        [DefaultCommand]
        public void TestFire(string[] @params, TPlayObject PlayObject)
        {
            int nRange = @params.Length > 0 ? int.Parse(@params[0]) : 0;
            int nType = @params.Length > 1 ? int.Parse(@params[1]) : 0;
            uint nTime = @params.Length > 2 ? uint.Parse(@params[2]) : 0;
            int nPoint = @params.Length > 3 ? int.Parse(@params[3]) : 0;

            TFireBurnEvent FireBurnEvent;
            int nMinX = PlayObject.m_nCurrX - nRange;
            int nMaxX = PlayObject.m_nCurrX + nRange;
            int nMinY = PlayObject.m_nCurrY - nRange;
            int nMaxY = PlayObject.m_nCurrY + nRange;
            for (int nX = nMinX; nX <= nMaxX; nX++)
            {
                for (int nY = nMinY; nY <= nMaxY; nY++)
                {
                    if (((nX < nMaxX) && (nY == nMinY)) || ((nY < nMaxY) && (nX == nMinX)) || (nX == nMaxX) || (nY == nMaxY))
                    {
                        FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY, nType, nTime * 1000, nPoint);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                    }
                }
            }
        }
    }
}