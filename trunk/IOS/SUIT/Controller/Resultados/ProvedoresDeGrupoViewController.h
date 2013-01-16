//
//  ProvedoresDeGrupoViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 10/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "ProvedoresListViewController.h"
#import "Grupo.h"

@interface ProvedoresDeGrupoViewController : ProvedoresListViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil grupo:(Grupo*)grupo;

@property(nonatomic,retain) NSArray* serviciosDeGrupo;
@property(nonatomic,retain) Grupo* grupo;


@end
