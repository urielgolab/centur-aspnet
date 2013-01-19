//
//  BaseViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "BaseViewController.h"
#import "LoginViewController.h"
#import "SRVProfile.h"
#import "LoginEditViewController.h"

@interface BaseViewController ()

@property(nonatomic,retain) UITableView* tableView;

@end

@implementation BaseViewController

@synthesize tableView = _tableView;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        NSArray * items = [NSArray arrayWithObjects: 
                           [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"login.png"] 
                                                            style:UIBarButtonItemStyleBordered target:self action:@selector(showLogin)],
                           [[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemFlexibleSpace target:nil action:nil],
                           [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"home.png"] 
                                                            style:UIBarButtonItemStyleBordered target:self action:@selector(goHome)],
                           nil];
        self.toolbarItems = items;
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

- (void)goHome{
    [self.navigationController popToRootViewControllerAnimated:YES];
}

-(void)showLogin{
    UIViewController* lg;
    if (![SRVProfile GetInstance].currentUser ) {
        lg = [[LoginViewController alloc ]initWithNibName:@"LoginViewController" bundle:nil];
    }else{
        lg = [[LoginEditViewController alloc] initWithNibName:@"LoginEditViewController" bundle:nil];
    }
    UINavigationController* nc = [[UINavigationController alloc]initWithRootViewController:lg];
    [self.navigationController presentModalViewController:nc animated:YES];
}

@end
