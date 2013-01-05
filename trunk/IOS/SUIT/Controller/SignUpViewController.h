//
//  SignUpViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 05/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface SignUpViewController : UIViewController<UITextFieldDelegate,UIScrollViewDelegate> {
    
    __weak IBOutlet UITextField *usuarioTextField;
    __weak IBOutlet UITextField *mailTextField;
    __weak IBOutlet UITextField *nombreTextField;
    __weak IBOutlet UITextField *apellidoTextField;
    __weak IBOutlet UITextField *telefonoTextField;
    __weak IBOutlet UITextField *pass1;
    __weak IBOutlet UITextField *pass2;
}
- (IBAction)regirar:(id)sender;

@end
