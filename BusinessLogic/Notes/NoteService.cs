using DataAccess.FileService;
using DataAccess.Settings;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogic
{
    public class NoteService : INoteService
    {
        private readonly IFileService fileService;
        private readonly ISetting setting;

        public NoteService(ISetting setting, IFileService fileService)
        {
            this.setting = setting;
            this.fileService = fileService;
            var files = from file in Directory.EnumerateFiles(setting.GroupFilesPath)
                        select Path.Combine(setting.GroupFilesPath, file);
        }
    }
}