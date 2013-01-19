//
//  LoginEditViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 17/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface LoginEditViewController : UIViewController{
    
    __weak IBOutlet UITextField *nombre;
    __weak IBOutlet UITextField *apellido;
    __weak IBOutlet UITextField *mail;
    __weak IBOutlet UITextField *telefono;
}
- (IBAction)guardar:(id)sender;

@end
