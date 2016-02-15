#import "KeyChainPlugin.h"
#import "UICKeyChainStore.h"
 
NSString *_keyForID = @"UserID";
NSString *_keyForUUID = @"UserUUID";
 
@implementation KeyChainPlugin
 
extern "C" {
    char* getKeyChainUser();
    void setKeyChainUser(const char* userId, const char* uuid);
    void deleteKeyChainUser();
}
 
char* getKeyChainUser()
{
    NSString *userId = [UICKeyChainStore stringForKey:_keyForID];
    NSString *userUUID = [UICKeyChainStore stringForKey:_keyForUUID];
 
    if (userId == nil || [userId isEqualToString:@""]) {
        NSLog(@"No user information");
        userId = @"";
        userUUID = @"";
    }
 
    NSString* json = [NSString stringWithFormat:@"{\"userId\":\"%@\",\"uuid\":\"%@\"}",userId,userUUID];
 
    return makeStringCopy([json UTF8String]);
}
 
void setKeyChainUser(const char* userId, const char* uuid)
{
    NSString *nsUseId = [NSString stringWithCString: userId encoding:NSUTF8StringEncoding];
    NSString *nsUUID = [NSString stringWithCString: uuid encoding:NSUTF8StringEncoding];
 
    [UICKeyChainStore setString:nsUseId forKey:_keyForID];
    [UICKeyChainStore setString:nsUUID forKey:_keyForUUID];
}
 
void deleteKeyChainUser()
{
    [UICKeyChainStore removeItemForKey:_keyForID];
    [UICKeyChainStore removeItemForKey:_keyForUUID];
}
 
char* makeStringCopy(const char* str)
{
    if (str == NULL) {
        return NULL;
    }
 
    char* res = (char*)malloc(strlen(str) + 1);
    strcpy(res, str);
    return res;
}
 
@end