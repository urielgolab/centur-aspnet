//
//  LoginViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "LoginViewController.h"
#import "SRVProfile.h"
#import "SignUpViewController.h"

typedef enum {
    AlertTypeLoginOK = 0,
    AlertTypeLoginFailed = 1
} AlertType;

@interface LoginViewController ()

@end

@implementation LoginViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.navigationItem.leftBarButtonItem = [[UIBarButtonItem alloc] initWithTitle:@"Cerrar" style:UIBarButtonItemStyleBordered target:self action:@selector(close)];
        self.navigationItem.rightBarButtonItem =[[UIBarButtonItem alloc] initWithTitle:@"Registrar" style:UIBarButtonItemStyleBordered target:self action:@selector(registrar)];
        [self createNotification];
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
}

- (void)viewDidUnload
{
    usuarioTextField = nil;
    passwordTextField = nil;
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

-(void)close{
    [self.navigationController dismissModalViewControllerAnimated:YES];
}

-(void)registrar{
    SignUpViewController *sg = [[SignUpViewController alloc]initWithNibName:@"SignUpViewController" bundle:nil];    
    [self.navigationController pushViewController:sg animated:YES];
}

- (IBAction)loginTouch:(UIButton *)sender {
    if ([self canCreateUser]){
        [[SRVProfile GetInstance] loginUserName:usuarioTextField.text withPassword:passwordTextField.text];
    }
}

-(BOOL)canCreateUser{
    return [usuarioTextField.text length]>6 && [usuarioTextField.text length]>5;
}

#pragma mark Notification

-(void)createNotification{
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(loginOK:) 
                                                 name:SERVICE_LOGIN_OK 
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(loginFailed:) 
                                                 name:SERVICE_LOGIN_FAILED 
                                               object:nil];

}

-(void)loginOK:(NSNotification*)notification{
    UIAlertView* alert = [[UIAlertView alloc] initWithTitle:@"Mensaje" message:@"Logeo correcto" delegate:self cancelButtonTitle:@"Aceptar" otherButtonTitles: nil];
    alert.tag = AlertTypeLoginOK;
    [alert show];

}

-(void)loginFailed:(NSNotification*)notification{
    UIAlertView* alert = [[UIAlertView alloc] initWithTitle:@"Mensaje" message:@"Usuario y contraseña no validos" delegate:self cancelButtonTitle:@"Aceptar" otherButtonTitles: nil];
    alert.tag = AlertTypeLoginFailed;
    [alert show];
}


- (void)alertView:(UIAlertView *)alertView didDismissWithButtonIndex:(NSInteger)buttonIndex{
    AlertType alertType = alertView.tag;
    
    if (alertType == AlertTypeLoginOK) {
        [self close];
    }else if (alertType == AlertTypeLoginFailed) {
        
    }
}

@end
