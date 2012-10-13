//
//  Hora.h
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Hora : NSObject{
    NSDate* horaMinima;
    NSDate* horaMaxima;
}

@property(nonatomic,readonly) NSDate* horaMinima;
@property(nonatomic,readonly) NSDate* horaMaxima;

@end
