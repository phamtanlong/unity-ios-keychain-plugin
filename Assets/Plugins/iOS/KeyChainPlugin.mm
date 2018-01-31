#import "KeyChainPlugin.h"
#import "UICKeyChainStore.h"

UICKeyChainStore* _activeKeychain = nil;

@implementation KeyChainPlugin

extern "C"
{
    void initialize(const char* serviceID);
    
    char* getString(const char* key, const char* defaultValue);
    void setString(const char* key, const char* value);
    void deleteKey(const char* key);
    void printOutAllItems();
}

void initialize(const char* serviceID)
{
    NSString* nsServiceID = toNSString(serviceID);
    
    _activeKeychain = [UICKeyChainStore keyChainStoreWithService: nsServiceID];
    _activeKeychain.accessibility = UICKeyChainStoreAccessibilityWhenUnlocked;
    _activeKeychain.synchronizable = YES;
}

char* getString(const char* key, const char* defaultValue)
{
    if(_activeKeychain == nil)
    {
        NSLog(@"Keychain plugin is not initialized! Aborting getString");
        return makeStringCopy(defaultValue);
    }
    
    NSString* nsKey = toNSString(key);
    NSString* nsValue = _activeKeychain[nsKey];
    
    if (nsValue == nil || [nsValue isEqualToString:@""])
    {
        return makeStringCopy(defaultValue);
    }
    
    return makeStringCopy([nsValue UTF8String]);
}

void setString(const char* key, const char* value)
{
    if(_activeKeychain == nil)
    {
        NSLog(@"Keychain plugin is not initialized! Aborting setString");
        return;
    }
    
    NSString* nsKey = toNSString(key);
    NSString* nsValue = toNSString(value);
    
    _activeKeychain[nsKey] = nsValue;
}

void deleteKey(const char* key)
{
    if(_activeKeychain == nil)
    {
        NSLog(@"Keychain plugin is not initialized! Aborting deleteKey");
        return;
    }
    
    NSString* nsKey = toNSString(key);
    [_activeKeychain removeItemForKey:nsKey];
}

void printOutAllItems()
{
    if(_activeKeychain == nil)
    {
        NSLog(@"Keychain plugin is not initialized! Aborting printOutAllItems");
        return;
    }
    
    NSLog(@"%@", _activeKeychain);
}

char* makeStringCopy(const char* str)
{
    if (str == NULL)
    {
        return NULL;
    }
    
    char* res = (char*)malloc(strlen(str) + 1);
    strcpy(res, str);
    return res;
}

NSString* toNSString(const char* str)
{
    return [NSString stringWithCString: str encoding:NSUTF8StringEncoding];
}

@end
