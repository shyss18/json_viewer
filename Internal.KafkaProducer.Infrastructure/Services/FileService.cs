using Internal.KafkaProducer.Core.Contracts.Services;
using Microsoft.Win32;

namespace Internal.KafkaProducer.Infrastructure.Services
{
    internal class FileService : IFileService
    {
        public string PeekFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            return null;
        }
    }
}