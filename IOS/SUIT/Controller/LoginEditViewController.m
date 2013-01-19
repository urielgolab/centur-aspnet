//
//  LoginEditViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 17/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "LoginEditViewController.h"
#import "SRVProfile.h"
@interface LoginEditViewController ()

@end

@implementation LoginEditViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.navigationItem.leftBarButtonItem = [[UIBarButtonItem alloc] initWithTitle:@"Cerrar" style:UIBarButtonItemStyleBordered target:self action:@selector(close)];
        self.navigationItem.rightBarButtonItem =[[UIBarButtonItem alloc] initWithTitle:@"Salir" style:UIBarButtonItemStyleBordered target:self action:@selector(Salir)];
        self.title = [SRVProfile GetInstance].currentUser.nombreUsuario;
        [self createNotification];
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewDidUnload {
    nombre = nil;
    mail = nil;
    apellido = nil;
    telefono = nil;
    [super viewDidUnload];
}

-(void)createNotification{
    
}

-(void)viewWillAppear:(BOOL)animated{
    
    [super viewWillAppear:animated];
    Usuario* usuario = [SRVProfile GetInstance].currentUser;
    nombre.text = usuario.nombre;
    apellido.text = usuario.apellido;
    mail.text = usuario.mail;
    telefono.text = usuario.telefono;
    
}

-(void)close{
    [self.navigationController dismissModalViewControllerAnimated:YES];
}

-(void)Salir{
    [SRVProfile GetInstance].currentUser = nil;
    [self.navigationController dismissModalViewControllerAnimated:YES];
}

- (IBAction)guardar:(id)sender {
    Usuario* usuario = [SRVProfile GetInstance].currentUser;
    usuario.nombre =  ([nombre.text length]) ? nombre.text : usuario.nombre;
    usuario.apellido =  ([apellido.text length]) ? apellido.text : usuario.apellido;
    usuario.telefono = ([telefono.text length]) ? telefono.text : usuario.telefono;
    usuario.mail = ([mail.text length]) ? mail.text : usuario.mail;

    [[SRVProfile GetInstance] saveUsuario];
}
@end
