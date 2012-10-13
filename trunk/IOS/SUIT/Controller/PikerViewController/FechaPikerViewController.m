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

@synthesize fecheable;
@dynamic view;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
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
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

-(void)viewWillDisappear:(BOOL)animated{
    [super viewWillDisappear:animated];
    Fecha * fecha = [[Fecha alloc] init];
    fecha.fechaDesde = pikerDesde.date;
    fecha.fechaHasta = pikerHasta.date;
    self.fecheable.fecha = fecha;
}

-(void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    [scroll setContentSize:CGSizeMake(scroll.frame.size.width,CGRectGetMaxY(pikerHasta.frame))];
    
    if (fecheable.fecha.fechaDesde) {
        [pikerDesde setDate:fecheable.fecha.fechaDesde];
    }
    if (fecheable.fecha.fechaHasta) {
        [pikerHasta setDate:fecheable.fecha.fechaHasta];
    }
    
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

@end
