//
//  FechaPikerViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "FechaPikerViewController.h"

@interface FechaPikerViewController ()


@end

@implementation FechaPikerViewController

@dynamic view;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
        self.navigationItem.leftBarButtonItem = [[UIBarButtonItem alloc] initWithTitle:@"Cerrar" style:UIBarButtonItemStyleBordered target:self action:@selector(close)];
        self.navigationItem.rightBarButtonItem =[[UIBarButtonItem alloc] initWithTitle:@"Buscar" style:UIBarButtonItemStyleBordered target:self action:@selector(buscar)];
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    datePiker.minimumDate = self.minunDate;
    datePiker.maximumDate = self.maxDate;
    // Do any additional setup after loading the view from its nib.
}

- (void)viewDidUnload
{
    datePiker = nil;
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

-(void)viewWillDisappear:(BOOL)animated{
    [super viewWillDisappear:animated];

}

-(void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

-(void)close{
    [self.navigationController dismissModalViewControllerAnimated:YES];
}

-(void) buscar{
    self.searchBlock(datePiker.date);
    [self.navigationController dismissModalViewControllerAnimated:YES];
}

@end
