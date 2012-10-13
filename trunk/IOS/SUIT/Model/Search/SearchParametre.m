//
//  SearchParametre.m
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SearchParametre.h"

@implementation SearchParametre

-(BOOL)canPerformSearch{
    [NSException raise:@"Subclass responsability" format:@"Implemente: CanPerformSearch in %@",[self classForCoder]];
    return NO;
}

@end
