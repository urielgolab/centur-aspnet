//
//  MercadoPagoViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 20/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "MercadoPagoViewController.h"
#import "SRVProfile.h"
@interface MercadoPagoViewController ()

@end

@implementation MercadoPagoViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andServicio:(Servicio*)servicio andTurno:(Turno*)turno
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.turno = turno;
        self.servicio = servicio;
         self.navigationItem.leftBarButtonItem = [[UIBarButtonItem alloc] initWithTitle:@"Cerrar" style:UIBarButtonItemStyleBordered target:self action:@selector(close)];
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    
    NSURL *url = [NSURL URLWithString:[NSString stringWithFormat:BASE_MERCADO_PAGO,self.servicio.ID,[SRVProfile GetInstance].currentUser.usuarioID]];
    NSURLRequest *request= [NSURLRequest requestWithURL:url];
    [self.webView loadRequest:request];
    // Do any additional setup after loading the view from its nib.
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewDidUnload {
    [self setWebView:nil];
    [super viewDidUnload];
}

-(void)close{
    [self dismissModalViewControllerAnimated:YES];
}

-(BOOL)webView:(UIWebView *)webView shouldStartLoadWithRequest:(NSURLRequest *)request navigationType:(UIWebViewNavigationType)navigationType{
    
    NSLog(@"%@",request);
    
    return YES;
}

-(void)webView:(UIWebView *)webView didFailLoadWithError:(NSError *)error{
    NSLog(@"%@",error);
    [[[UIAlertView alloc]initWithTitle:@"Error en reserva" message:@"Comuniquese con el proveedor del servicio" delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles:nil]show];
    
    //[self.navigationController dismissModalViewControllerAnimated:YES];
}

@end
