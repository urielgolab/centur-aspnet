//
//  TurnosViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 05/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "BaseViewController.h"

@interface TurnosViewController : BaseViewController<UIAlertViewDelegate>{
    Turno* selectedTurno;
}

@property(nonatomic,retain) NSArray* turnos;
@property(nonatomic,retain) Servicio* servicio;

@end
