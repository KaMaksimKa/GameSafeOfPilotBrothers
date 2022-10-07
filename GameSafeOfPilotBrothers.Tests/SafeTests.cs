using GameSafeOfPilotBrothers.Models;

namespace GameSafeOfPilotBrothers.Tests
{
    public class SafeTests
    {
        [Fact]
        public void LockConditionTests()
        {
            bool[,] openedLockFalse =
            {
                 {false, false,false},
                 {false, false,false},
                 {false, false,false}
            };
            bool[,] openedLockTrue =
            {
                 {true, true, true},
                 {true, true, true},
                {true, true, true}
            };
            bool[,] closedLock =
            {
                 {false, false,false},
                 {false, true,false},
                {false, false,false}
            };
            bool[,] willOpenLock =
            {
                 {false, true, false}, 
                 { true, true,true},
                 {false, true, false}
            };
            Safe openedSafeTrue = new Safe(new LockOfSafeFactoryInLikeness(openedLockTrue) );
            Safe openedSafeFalse = new Safe(new LockOfSafeFactoryInLikeness(openedLockFalse));
            Safe closedSafe = new Safe(new LockOfSafeFactoryInLikeness(closedLock));
            Safe willOpenSafe = new Safe(new LockOfSafeFactoryInLikeness(willOpenLock));
            willOpenSafe.TurnHandle(new PositionInLock(1, 1));

            Assert.Equal(LockConditionEnum.Open, openedSafeTrue.LockCondition);
            Assert.Equal(LockConditionEnum.Open, openedSafeFalse.LockCondition);
            Assert.Equal(LockConditionEnum.Close, closedSafe.LockCondition);
            Assert.Equal(LockConditionEnum.Open, willOpenSafe.LockCondition);
        }

        [Fact]
        public void TurnHandleTests()
        {
            bool[,] firstStartLock =
            {
                {false, false,false},
                {false, false,false},
                {false, false,false}
            };

            bool[,] firstFinishLock =
            {
                {false, true,false},
                {true, true,true},
                {false, true,false}
            };
            Safe firstSafe = new Safe(new LockOfSafeFactoryInLikeness(firstStartLock) );
            firstSafe.TurnHandle(new PositionInLock(1, 1));



            bool[,] secondStartLock =
            {
                {true, false,false,true},
                {false, false,true,false},
                {true, true,false, false},
                {false, true,false, true}
            };

            bool[,] secondFinishLock =
            {
                {false, true,true,false},
                {false, false,false,false},
                {true, true,true, false},
                {false, true,true, true}
            };
            Safe secondSafe = new Safe(new LockOfSafeFactoryInLikeness(secondStartLock) );

            secondSafe.TurnHandle(new PositionInLock(0, 2));


            Assert.Equal(firstFinishLock,firstSafe.HandleLock);
            Assert.Equal(secondFinishLock, secondSafe.HandleLock);




        }

    }
}