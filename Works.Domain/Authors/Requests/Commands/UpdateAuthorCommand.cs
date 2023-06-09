﻿using System.Text.Json.Serialization;
using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Authors.Requests.Commands;

public class UpdateAuthorCommand : IRequest<UpdateAuthorResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string? Alias { get; set; }

    public string? PublicEmail { get; set; }

    public string? Description { get; set; }
}