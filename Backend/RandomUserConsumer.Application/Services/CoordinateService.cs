﻿using RandomuserConsumer.Communication.Request.User;
using RandomuserConsumer.Communication.Responses.RandomUserApi;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Coordinate;

namespace RandomUserConsumer.Application.Services;

public class CoordinateService
{
    private readonly ICoordinateWriteRepository _coordinateWriteRepository;
    
    public CoordinateService(ICoordinateWriteRepository addressWriteRepository)
    {
        _coordinateWriteRepository = addressWriteRepository;
    }
    
    public async Task<Coordinate> RigisterCoordinate(int idAddress, ResponseRandomUserGereted userGereted)
    {
        double latitude, logitude;
        if (!double.TryParse(userGereted.Results.First().Location.Coordinates.Latitude, out latitude))
        {
            latitude = 0;
        }
        
        if (!double.TryParse(userGereted.Results.First().Location.Coordinates.Longitude, out logitude))
        {
            logitude = 0;
        }
        
        Coordinate entityCoordinate = new Coordinate()
        {
            IdAddress = idAddress,
            Latitude = latitude,
            Longitude = logitude,
        };
        
        return await _coordinateWriteRepository.Add(entityCoordinate);
    }
    
    public async Task<Coordinate> RigisterCoordinate(int idAddress, RequestRegisterUser dto)
    {
        Coordinate entityCoordinate = new Coordinate()
        {
            IdAddress = idAddress,
            Latitude = dto.Address.Latitude,
            Longitude = dto.Address.Longitude,
        };
        
        return await _coordinateWriteRepository.Add(entityCoordinate);
    }
}