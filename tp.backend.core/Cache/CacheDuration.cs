namespace tp.shared.Cache;

public static class CacheDuration
{
    public const int FromMin5 = 5 * 60;
    public const int FromMin10 = 10 * 60;
    public const int FromMin15 = 15 * 60;
    public const int FromMin20 = 20 * 60;
    public const int FromMin30 = 30 * 60;
    public const int FromHour1 = 60 * 60;
    public const int FromHour2 = FromHour1 * 2;
    public const int FromHour4 = FromHour1 * 4;
    public const int FromHour8 = FromHour1 * 8;
    public const int FromHour16 = FromHour1 * 16;
    public const int FromDay1 = FromHour1 * 24;
    public const int FromDay2 = FromDay1 * 2;
    public const int FromDay4 = FromDay1 * 4;
    public const int FromDay8 = FromDay1 * 8;
    public const int FromDay16 = FromDay1 * 16;
    public const int FromMonth1 = FromDay1 * 30;
    public const int Eternal = 0;
}