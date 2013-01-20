//
//  MercadoPagoViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 20/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "BaseViewController.h"

@interface MercadoPagoViewController : UIViewController<UIWebViewDelegate>

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andServicio:(Servicio*)servicio andTurno:(Turno*)turno;

@property(nonatomic,retain) Servicio* servicio;
@property(nonatomic,retain) Turno* turno;
@property (weak, nonatomic) IBOutlet UIWebView *webView;

@end
