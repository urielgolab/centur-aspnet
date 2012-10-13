//
//  LoginViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface LoginViewController : UIViewController<UIAlertViewDelegate>{
    
    IBOutlet UITextField *usuarioTextField;
    IBOutlet UITextField *passwordTextField;
    
}
- (IBAction)loginTouch:(UIButton *)sender;

@end
