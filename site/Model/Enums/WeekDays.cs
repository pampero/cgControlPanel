using System;

public class Weekdays
{
    // Enumerated data with Flags for setting 
    // each corresponding bit among 7 bits
    [Flags]
    enum weekday
    { 
        Sun = 1,
        Mon = 2,
        Tue = 4,
        Wed = 8,
        Thu = 16,
        Fri = 32,
        Sat = 64
    };
    
    // Store boolean values for seven days
    private bool sunday;
    private bool monday;
    private bool tuesday;
    private bool wednesday;
    private bool thursday;
    private bool friday;
    private bool saturday;
    
    // Expose the properties outside
    public bool Sunday
    {
        get { return sunday; }
        set { sunday = value; }
    }
    public bool Monday
    {
        get { return monday; }
        set { monday = value; }
    }
    public bool Tuesday
    {
        get { return tuesday; }
        set { tuesday = value; }
    }
    public bool Wednesday
    {
        get { return wednesday; }
        set { wednesday = value; }
    }
    public bool Thursday
    {
        get { return thursday; }
        set { thursday = value; }
    }
    public bool Friday
    {
        get { return friday; }
        set { friday = value; }
    }
    public bool Saturday
    {
        get { return saturday; }
        set { saturday = value; }
    }
    
    // Making all the days to be jointly interpreted as a single byte
    public byte AllDays
    {
        get
        {
            byte Value = 0;
            // from LSB to MSB - Sunday, Monday, Tuesday, 
            // Wednesday, Thursday, Friday, Saturday
            if (sunday) Value |= (byte)weekday.Sun ;
            if (monday) Value |= (byte)weekday.Mon ;
            if (tuesday) Value |= (byte)weekday.Tue;
            if (wednesday) Value |= (byte)weekday.Wed;
            if (thursday) Value |= (byte)weekday.Thu;
            if (friday) Value |= (byte)weekday.Fri;
            if (saturday) Value |= (byte)weekday.Sat;
            return Value;
        }
        set
        {
            // Extract the corresponding bits for each weekday
            // into bool properties of the class
            sunday = ((value & (byte)weekday.Sun) != 0 );
            monday = ((value & (byte)weekday.Mon) != 0);
            tuesday = ((value & (byte)weekday.Tue) != 0);
            wednesday = ((value & (byte)weekday.Wed) != 0);
            thursday = ((value & (byte)weekday.Thu) != 0);
            friday = ((value & (byte)weekday.Fri) != 0);
            saturday = ((value & (byte)weekday.Sat) != 0);
        }
    }
}