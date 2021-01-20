using System.IO;

namespace ImageToFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            var sources = @"C:\ImageToFolder\sources\";
            var targets = @"C:\ImageToFolder\targets\";

            // 폴더 정보 읽어오기
            DirectoryInfo d = new DirectoryInfo(sources);

            // 특정 폴더의 모든 파일 정보 읽어오기
            FileInfo[] infos = d.GetFiles();

            // 파일 정보를 반복하면서 파일의 이름으로 5자까지만 생성해서 이동
            int folderCount = 1;
            int count = 1;
            foreach (FileInfo f in infos)
            {
                if (count % 15 == 0)
                {
                    folderCount++; // folder max count == 15
                }
                Directory.CreateDirectory($"{targets}\\{folderCount}");
                File.Move(f.FullName, $"{targets}\\{folderCount}\\{f.Name}");
                count++;
            }
        }
    }
}
