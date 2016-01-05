/*
 * ストレージ空き容量の取得(MegaBite)
 */
extern "C" {
    int availableStorage_();
}

int availableStorage_() {
    uint64_t totalSpace = 0;
    uint64_t totalFreeSpace = 0;
    uint64_t MB = 1024 * 1024;

    __autoreleasing NSError *error = nil;
    NSArray *paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSDictionary *dictionary = [[NSFileManager defaultManager] attributesOfFileSystemForPath:[paths lastObject] error: &error];
    
    if (dictionary) {
        NSNumber *fileSystemSizeInBytes = [dictionary objectForKey: NSFileSystemSize];
        NSNumber *freeFileSystemSizeInBytes = [dictionary objectForKey:NSFileSystemFreeSize];
        totalFreeSpace = [freeFileSystemSizeInBytes unsignedLongLongValue];
    }
    
    return totalFreeSpace / MB;
}