using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;

public class Coffee
{
    public string CoffeeType { get; set; }
    public int CoffeeAvailability { get; set; }
    public decimal CoffeePrice { get; set; }
    public Coffee(string CoffeeType, int CoffeeAvailability, decimal CoffeePrice)
    {
        if (CoffeePrice < 0) { Console.WriteLine("Price can't be negative"); }
        else
        {
            this.CoffeePrice = CoffeePrice;
        }
        this.CoffeeType = CoffeeType;
        this.CoffeePrice = CoffeePrice;
    }
}
public class Milk
{
    public string MilkType { get; set; }
    public int MilkAvailability { get; set; }
    public decimal MilkPrice { get; set; }
    public Milk(string MilkType, int MilkAvailability, decimal MilkPrice)
    {
        if (MilkPrice < 0) { Console.WriteLine("Price can't be negative"); }
        else
        {
            this.MilkPrice = MilkPrice;
        }
        this.MilkType = MilkType;
        this.MilkPrice = MilkPrice;
    }
}
public class Supplement
{
    public string SupplementType { get; set; }
    public int SupplementAvailability { get; set; }
    public decimal SupplementPrice { get; set; }
    public Supplement(string SupplementType, int SupplementAvailability, decimal SupplementPrice)
    {
        if (SupplementPrice <= 0) { Console.WriteLine("Price can't be negative"); }
        else
        {
            this.SupplementPrice = SupplementPrice;
        }
        this.SupplementType = SupplementType;
        this.SupplementPrice = SupplementPrice;
    }
}
class Program
{
    
    static void Main(string[] args)
    {
        List<Coffee> CoffeeArray = new List<Coffee>();
        List<Milk> MilkArray = new List<Milk>();
        List<Supplement> SupplementArray = new List<Supplement>();
        List<Coffee> Coffee1Array = CoffeeArray;
        CoffeeArray.Add(new Coffee("americano", 23, 25m));
        CoffeeArray.Add(new Coffee("cap", 25, 100m));
        Console.WriteLine(Coffee1Array[0].CoffeeType);
        string x = "@echo off\r\nchcp 65001 >nul\r\n:: 65001 - UTF-8\r\n\r\ncd /d \"%~dp0..\\\"\r\nset BIN=%~dp0..\\bin\\\r\n\r\nset LIST_TITLE=ZAPRET: Ultimate Fix\r\nset LIST_PATH=%~dp0..\\lists\\list-ultimate.txt\r\nset GMODE_FLAG_FILE=%BIN%gmode.flag\r\nset DISCORD_IPSET_PATH=%~dp0..\\lists\\ipset-discord.txt\r\nset CLOUDFLARE_IPSET_PATH=%~dp0..\\lists\\ipset-cloudflare.txt\r\n\r\nif exist \"%GMODE_FLAG_FILE%\" (\r\n    set \"GModeStatus=enabled\"\r\n    set \"GModeRange=1024-65535\"\r\n) else (\r\n    set \"GModeStatus=disabled\"\r\n    set \"GModeRange=0\"\r\n)\r\n\r\nstart \"%LIST_TITLE%\" /min \"%BIN%winws.exe\" --wf-tcp=80,443,2053,2083,2087,2096,8443,%GModeRange% --wf-udp=443,19294-19344,50000-50100,%GModeRange% ^\r\n--filter-udp=443 --hostlist=\"%LIST_PATH%\" --dpi-desync=fake --dpi-desync-repeats=6 --dpi-desync-fake-quic=\"%BIN%quic_initial_www_google_com.bin\" --new ^\r\n--filter-udp=19294-19344,50000-50100 --filter-l7=discord,stun --dpi-desync=fake --dpi-desync-repeats=6 --new ^\r\n--filter-tcp=80 --hostlist=\"%LIST_PATH%\" --dpi-desync=fake,multisplit --dpi-desync-autottl=2 --dpi-desync-fooling=md5sig --new ^\r\n--filter-tcp=2053,2083,2087,2096,8443 --hostlist-domains=discord.media --dpi-desync=fake,fakedsplit --dpi-desync-repeats=6 --dpi-desync-fooling=ts --dpi-desync-fakedsplit-pattern=0x00 --dpi-desync-fake-tls=\"%BIN%tls_clienthello_www_google_com.bin\" --new ^\r\n--filter-tcp=443 --hostlist=\"%LIST_PATH%\" --dpi-desync=fake,fakedsplit --dpi-desync-repeats=6 --dpi-desync-fooling=ts --dpi-desync-fakedsplit-pattern=0x00 --dpi-desync-fake-tls=\"%BIN%tls_clienthello_www_google_com.bin\" --new ^\r\n--filter-udp=443 --ipset=\"%CLOUDFLARE_IPSET_PATH%\" --dpi-desync=fake --dpi-desync-repeats=6 --dpi-desync-fake-quic=\"%BIN%quic_initial_www_google_com.bin\" --new ^\r\n--filter-tcp=80 --ipset=\"%CLOUDFLARE_IPSET_PATH%\" --dpi-desync=fake,multisplit --dpi-desync-autottl=2 --dpi-desync-fooling=md5sig --new ^\r\n--filter-tcp=443,%GModeRange% --ipset=\"%CLOUDFLARE_IPSET_PATH%\" --dpi-desync=fake,fakedsplit --dpi-desync-repeats=6 --dpi-desync-fooling=ts --dpi-desync-fakedsplit-pattern=0x00 --dpi-desync-fake-tls=\"%BIN%tls_clienthello_www_google_com.bin\" --new ^\r\n--filter-udp=%GModeRange% --ipset=\"%CLOUDFLARE_IPSET_PATH%\" --dpi-desync=fake --dpi-desync-autottl=2 --dpi-desync-repeats=12 --dpi-desync-any-protocol=1 --dpi-desync-fake-unknown-udp=\"%BIN%quic_initial_www_google_com.bin\" --dpi-desync-cutoff=n3";
        string y = "@echo off\r\nchcp 65001 > nul\r\n:: 65001 - UTF-8\r\n\r\ncd /d \"%~dp0\"\r\ncall service.bat status_zapret\r\ncall service.bat check_updates\r\ncall service.bat load_game_filter\r\necho:\r\n\r\nset \"BIN=%~dp0bin\\\"\r\nset \"LISTS=%~dp0lists\\\"\r\ncd /d %BIN%\r\n\r\nstart \"zapret: %~n0\" /min \"%BIN%winws.exe\" --wf-tcp=80,443,2053,2083,2087,2096,8443,%GameFilter% --wf-udp=443,19294-19344,50000-50100,%GameFilter% ^\r\n--filter-udp=443 --hostlist=\"%LISTS%list-general.txt\" --hostlist-exclude=\"%LISTS%list-exclude.txt\" --ipset-exclude=\"%LISTS%ipset-exclude.txt\" --dpi-desync=fake --dpi-desync-repeats=6 --dpi-desync-fake-quic=\"%BIN%quic_initial_www_google_com.bin\" --new ^\r\n--filter-udp=19294-19344,50000-50100 --filter-l7=discord,stun --dpi-desync=fake --dpi-desync-repeats=6 --new ^\r\n--filter-tcp=2053,2083,2087,2096,8443 --hostlist-domains=discord.media --dpi-desync=fake,fakedsplit --dpi-desync-repeats=6 --dpi-desync-fooling=ts --dpi-desync-fakedsplit-pattern=0x00 --dpi-desync-fake-tls=\"%BIN%tls_clienthello_www_google_com.bin\" --new ^\r\n--filter-tcp=443 --hostlist=\"%LISTS%list-google.txt\" --ip-id=zero --dpi-desync=fake,fakedsplit --dpi-desync-repeats=6 --dpi-desync-fooling=ts --dpi-desync-fakedsplit-pattern=0x00 --dpi-desync-fake-tls=\"%BIN%tls_clienthello_www_google_com.bin\" --new ^\r\n--filter-tcp=80,443 --hostlist=\"%LISTS%list-general.txt\" --hostlist-exclude=\"%LISTS%list-exclude.txt\" --ipset-exclude=\"%LISTS%ipset-exclude.txt\" --dpi-desync=fake,fakedsplit --dpi-desync-repeats=6 --dpi-desync-fooling=ts --dpi-desync-fakedsplit-pattern=0x00 --dpi-desync-fake-tls=\"%BIN%tls_clienthello_www_google_com.bin\" --new ^\r\n--filter-udp=443 --ipset=\"%LISTS%ipset-all.txt\" --hostlist-exclude=\"%LISTS%list-exclude.txt\" --ipset-exclude=\"%LISTS%ipset-exclude.txt\" --dpi-desync=fake --dpi-desync-repeats=6 --dpi-desync-fake-quic=\"%BIN%quic_initial_www_google_com.bin\" --new ^\r\n--filter-tcp=80,443,%GameFilter% --ipset=\"%LISTS%ipset-all.txt\" --hostlist-exclude=\"%LISTS%list-exclude.txt\" --ipset-exclude=\"%LISTS%ipset-exclude.txt\" --dpi-desync=fake,fakedsplit --dpi-desync-repeats=6 --dpi-desync-fooling=ts --dpi-desync-fakedsplit-pattern=0x00 --dpi-desync-fake-tls=\"%BIN%tls_clienthello_www_google_com.bin\" --new ^\r\n--filter-udp=%GameFilter% --ipset=\"%LISTS%ipset-all.txt\" --ipset-exclude=\"%LISTS%ipset-exclude.txt\" --dpi-desync=fake --dpi-desync-autottl=2 --dpi-desync-repeats=12 --dpi-desync-any-protocol=1 --dpi-desync-fake-unknown-udp=\"%BIN%quic_initial_www_google_com.bin\" --dpi-desync-cutoff=n3\r\n\r\n";
        Console.WriteLine(x==y);
    }
}