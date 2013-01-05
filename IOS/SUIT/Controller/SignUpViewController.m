//
//  SignUpViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 05/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "SignUpViewController.h"
#import "SRVProfile.h"

@interface SignUpViewController ()

@end

@implementation SignUpViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
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
    usuarioTextField = nil;
    mailTextField = nil;
    nombreTextField = nil;
    apellidoTextField = nil;
    telefonoTextField = nil;
    pass1 = nil;
    pass2 = nil;
    [super viewDidUnload];
}

-(void)registrar{
    [[SRVProfile GetInstance]registrarNombreUsuario:usuarioTextField.text password:pass1.text telefono:telefonoTextField.text nombre:nombreTextField.text apellido:apellidoTextField.text email:mailTextField.text];
}


-(void)createNotification{
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(SignOK:)
                                                 name:SERVICE_SIGN_OK
                                               object:nil];
    
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(SignFail:)
                                                 name:SERVICE_SIGN_FAILED
                                               object:nil];

    
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(keyboardWillShow:)
                                                 name:UIKeyboardWillShowNotification
                                               object:nil];
    
    // Register notification when the keyboard will be hided
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(keyboardWillHide:)
                                                 name:UIKeyboardWillHideNotification
                                               object:nil];
}

-(void)SignOK:(NSNotification*)notification{
    [self.navigationController dismissModalViewControllerAnimated:YES];
}

-(void)SignFail:(NSNotification*)notification{
    [[[UIAlertView alloc]initWithTitle:nil message:@"Error en registrar" delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles:nil]show];
}

-(void)keyboardWillShow:(NSNotification*)notification{
    //Subclass responsability
    CGFloat duration = [[notification.userInfo objectForKey:UIKeyboardAnimationDurationUserInfoKey]floatValue];
    CGRect rect;
    [[notification.userInfo objectForKey:UIKeyboardFrameEndUserInfoKey] getValue: &rect];
    
    [UIView animateWithDuration: duration animations:^(){
        self.view.frame = CGRectMake(0 , 0 ,
                                             self.view.bounds.size.width,
                                             self.view.bounds.size.height-
                                             rect.size.height
                                             );
        ((UIScrollView*) self.view).contentSize = CGSizeMake(320, 416);
    }completion:^(BOOL finished){
//        if (self.lastIndexPathFacus) {
//            [self.currencyList scrollToRowAtIndexPath:self.lastIndexPathFacus atScrollPosition:UITableViewScrollPositionNone animated:YES];
//            self.lastIndexPathFacus=nil;
//        }
    }];
}

-(void)keyboardWillHide:(NSNotification*)notification{
    //Subclass responsability
    CGFloat duration = [[notification.userInfo objectForKey:UIKeyboardAnimationDurationUserInfoKey]floatValue];
    CGRect rect;
    [[notification.userInfo objectForKey:UIKeyboardFrameEndUserInfoKey] getValue: &rect];
    
    [UIView animateWithDuration: duration animations:^(){
        self.view.frame = CGRectMake(0 , 0,
                                            320,
                                             416);
    }completion:^(BOOL finished){
        
    }];
}

- (void)textFieldDidBeginEditing:(UITextField *)textField{
    ((UIScrollView*) self.view).contentOffset = CGPointMake(0, CGRectGetMinY(textField.frame));
}

- (BOOL)textFieldShouldReturn:(UITextField *)textField{
    [textField resignFirstResponder];
    
    if ([textField isEqual:usuarioTextField]) [mailTextField becomeFirstResponder];
    if ([textField isEqual:mailTextField]) [nombreTextField becomeFirstResponder];
    if ([textField isEqual:nombreTextField]) [apellidoTextField becomeFirstResponder];
    if ([textField isEqual:apellidoTextField]) [telefonoTextField becomeFirstResponder];
    if ([textField isEqual:telefonoTextField]) [pass1 becomeFirstResponder];
    if ([textField isEqual:pass1]) [pass2 becomeFirstResponder];
    if ([textField isEqual:pass1]) [self registrar];
    
    return YES;
}

- (IBAction)regirar:(id)sender {
    [self registrar];
}
@end
