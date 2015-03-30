require.config({
	baseUrl: 'Scripts/libs',
	paths: {
		jQurey: 'jquery-2.1.1.min',
		HTTPRequester: 'HTTPRequester'
	}
});

require(['../apps/03.Students-REST-API']);