//
//  UIButton+urlImages.m
//  Batangav2
//
//  Created by ManuelRKenar on 24/08/12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "UIButton+urlImages.h"
#import "UIImageView+AFNetworking.h"


@implementation UIButton (urlImages)


-(void)setImageUrl:(NSString *)urlString forState:(UIControlState)state{
    
  UIImageView* aux = [[UIImageView alloc]initWithFrame:self.bounds];
    
    NSURL* url = [[NSURL alloc]initWithString:urlString];
    NSURLRequest* request = [NSURLRequest requestWithURL:url];
    [aux setImageWithURLRequest:request 
               placeholderImage:nil 
                        success:^(NSURLRequest *request, NSHTTPURLResponse *response, UIImage *image){
                            [self setImage:image forState:state];
                        }
                        failure:nil];
    
}

@end
